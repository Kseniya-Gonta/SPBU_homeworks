import numpy


def WGSS(w, clusters, center, clustNum, degree = 2):
    res = 0
    for i, x in enumerate(w):
        if clustNum == clusters[i]:
            t = pow(np.linalg.norm(x - center), degree)
            res += t
    return res

def BGSS(w, centers, ns, degree = 2):
    g = km.barycenter(w)
    res = 0
    for i, c in enumerate(centers):
        x = pow(np.linalg.norm(g - c), degree)
        res += ns[i] * x
    return res

def CalinskiHarabasz(w, centers, ns, clusters, k):
    wgssSum = 0
    bgssSum = BGSS(w, centers, ns)
    for i in range(k):
        wgssSum += WGSS(w, clusters, centers[i], i)
    return bgssSum * (len(clusters) - k) / (wgssSum * (k - 1))
