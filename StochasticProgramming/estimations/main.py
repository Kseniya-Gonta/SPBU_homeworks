import kmeans
import numpy as np
from math import sqrt

from helpers import bgss, wgss, read_external_data
from printHelper import printAll

if __name__ == "__main__":
    input_image = "policemen.jpg"
    image, reshapedImage = kmeans.reshapeImage(input_image)
    min_k, max_k = 2, 15
    CalinskiHarabasz =  [0] * (max_k - min_k + 1)
    DaviesBouldin =  [0] * (max_k - min_k + 1)
    RandIndex =  [0] * (max_k - min_k + 1)
    FowlkesMallows = [0] * (max_k - min_k + 1)

    for k in range(min_k, max_k + 1):
        try:
            clusters = kmeans.startKmeans(reshapedImage, k)
            centers = kmeans.cluster_centroids(reshapedImage, clusters, k)

            forCheck = [0] * k
            for i in clusters:
                forCheck[i] += 1
            flag = False
            for i in forCheck:
                if i == 0:
                    flag = True
                    break
            if flag:
                continue


            # Calinski-Harabasz
            WGSS = 0
            BGSS = bgss(reshapedImage, centers, forCheck)
            for i in range(k):
                WGSS += wgss(reshapedImage, clusters, centers[i], i)
            CalinskiHarabasz[k - min_k] = BGSS * (len(clusters) - k) / (WGSS * (k - 1))

            # Davies-Bouldin
            meanDists = [0] * k
            for i in range(k):
                meanDists[i] = wgss(reshapedImage, clusters, centers[i], i, 1) / forCheck[i]
            for i in range(k):
                t = 0
                for j in range(k):
                    if i != j:
                        t = max(t, (meanDists[i] + meanDists[j]) / np.linalg.norm(centers[i] - centers[j]))
                DaviesBouldin[k - min_k] += t / k

            correct_partitioning, external_data = read_external_data("task_2_data_7.txt")
            clusters = kmeans.startKmeans(external_data, k)


            #Rand Index
            truePositive = 0
            trueNegative = 0
            falsePositive = 0
            falseNegative = 0
            for i in xrange(len(correct_partitioning)):
                for j in xrange(i + 1, len(correct_partitioning)):
                    if correct_partitioning[i] == correct_partitioning[j]:
                        if clusters[i] == clusters[j]:
                            truePositive += 1
                        else:
                            trueNegative += 1
                    else:
                        if clusters[i] == clusters[j]:
                            falsePositive += 1
                        else:
                            falseNegative += 1

            RandIndex[k - min_k] = (truePositive + falseNegative) / len(clusters)


            #Fowlkes-Mallows Index
            FowlkesMallows[k - min_k] = truePositive / (sqrt((truePositive + trueNegative) * (truePositive + falsePositive)))

        except Exception:
            pass

    printAll(CalinskiHarabasz, DaviesBouldin, RandIndex, FowlkesMallows, min_k, max_k)
