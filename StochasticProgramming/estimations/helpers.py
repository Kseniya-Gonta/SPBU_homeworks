import numpy as np


def centroid(w):
    center = np.zeros(w[0].size)
    count = 0
    for i, x in enumerate(w):
        for j in xrange(0, x.size):
            a = x[j].astype(int)
            center[j] += a
        count += 1
    for y in range(0, center.size):
        try:
            center[y] /= count
        except Exception:
            pass
    return center


def bgss(w, centers, ns, degree=2):
    g = centroid(w)
    result = 0
    for i, center in enumerate(centers):
        x = pow(np.linalg.norm(g - center), degree)
        result += ns[i] * x
    return result


def wgss(w, clusters, center, cluster_index, degree=2):
    res = 0
    for i, x in enumerate(w):
        if cluster_index == clusters[i]:
            t = pow(np.linalg.norm(x - center), degree)
            res += t
    return res


def read_external_data(input_file):
    f = open(input_file, 'r')
    s = f.read().split("\r\n")
    if s[-1] == '':
        s = s[:-1]
    result = np.empty([len(s), len(s[0].split(' ')) - 1])
    correct = [0] * len(s)
    for i, values in enumerate(s):
        x = values.split(' ')
        result[i] = np.array((float(x[1]), float(x[2])))
        correct[i] = int(x[0])

    return correct, result
