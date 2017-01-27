import scipy.spatial
from PIL import Image
import numpy as np


def run_cost(centroids, clusters, X):
    return sum(np.linalg.norm(X[i] - centroids[clusters[i]]) for i in xrange(len(clusters)))


def cluster_centroids(data, clusters, k=None):
    if k is None:
        k = np.max(clusters) + 1
    result = np.empty(shape=(k,) + data.shape[1:])
    for i in range(k):
        np.mean(data[clusters == i], axis=0, out=result[i])
    return result


def startKmeans(data, k=None, centroids=None, steps=50):
    if centroids is not None and k is not None:
        assert (k == len(centroids))
    elif centroids is not None:
        k = len(centroids)
    elif k is not None:
        centroids = data[np.random.choice(np.arange(len(data)), k, False)]
    else:
        raise RuntimeError("No K spacified!")

    for _ in range(max(steps, 1)):
        squaredDistances = scipy.spatial.distance.cdist(centroids, data, 'sqeuclidean')

        # Index of the closest centroid to each data point.
        clusters = np.argmin(squaredDistances, axis=0)
        new_centroids = cluster_centroids(data, clusters, k)
        if np.array_equal(new_centroids, centroids):
            break

        centroids = new_centroids

    return clusters


def reshapeImage(input_image):
    image = np.array(Image.open(input_image))
    X = image.reshape((image.shape[0] * image.shape[1], image.shape[2]))
    return image, X
