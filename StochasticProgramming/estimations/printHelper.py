import matplotlib.pyplot as plt

def printAll(CalinskiHarabasz, DaviesBouldin, Rand, FowMal, min_k, max_k):
    print("K boundaries: " + str(min_k) + " -- " + str(max_k))
    print("Davies-Bouldin: " + str(DaviesBouldin))
    print("Calinski-Harabasz: " + str(CalinskiHarabasz))
    print("Rand Index: " + str(Rand))
    print("Fowlkes-Mallows Index: " + str(FowMal))

    delta_CalHar = []
    for k in xrange(1, max_k - min_k):
        delta_CalHar.append(
            (CalinskiHarabasz[k + 1] - CalinskiHarabasz[k]) - (CalinskiHarabasz[k] - CalinskiHarabasz[k - 1]))

    for m in [DaviesBouldin, delta_CalHar]:
        min = (0, float("inf"))
        for i, x in enumerate(m):
            if x < min[1]:
                min = i, x
        print("Best K: " + str(min[0] + 1))

    x_range = range(min_k, max_k + 1)

    plt.plot(x_range, DaviesBouldin, 'ro')
    plt.ylabel('Davies-Bouldin')
    plt.show()

    plt.plot(x_range, CalinskiHarabasz, 'ro')
    plt.ylabel('Calinski-Harabasz')
    plt.show()

    plt.plot(x_range, Rand, 'ro')
    plt.ylabel('Rand Index')
    plt.show()

    plt.plot(x_range, FowMal, 'ro')
    plt.ylabel('Fowlkes-Mallows Index')
    plt.show()
