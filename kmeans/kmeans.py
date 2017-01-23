#!/usr/bin/python
from PIL import Image
import numpy


# Will detewrmine if the centroids have converged or not.
# Essentially, if the current centroids and the old centroids
# are virtually the same, then there is convergence.
#
# Absolute convergence may not be reached, due to oscillating
# centroids. So a given range has been implemented to observe
# if the comparisons are within a certain ballpark
def converged(centroids, old_centroids):
    if len(old_centroids) == 0:
        return False

    if len(centroids) <= 5:
        a = 1
    elif len(centroids) <= 10:
        a = 2
    else:
        a = 4

    for i in range(0, len(centroids)):
        cent = centroids[i]
        old_cent = old_centroids[i]

        if ((int(old_cent[0]) - a) <= cent[0] <= (int(old_cent[0]) + a)) \
                and ((int(old_cent[1]) - a) <= cent[1] <= (int(old_cent[1]) + a)) \
                and ((int(old_cent[2]) - a) <= cent[2] <= (int(old_cent[2]) + a)):
            continue
        else:
            return False

    return True


# Method used to find the closest centroid to the given pixel.
def getClosestCentroid(pixel, centroids):
    minDist = 9999
    minIndex = 0

    for i in range(0, len(centroids)):
        d = numpy.sqrt(int((centroids[i][0] - pixel[0])) ** 2 + int((centroids[i][1] - pixel[1])) ** 2 + int(
            (centroids[i][2] - pixel[2])) ** 2)
        if d < minDist:
            minDist = d
            minIndex = i

    return minIndex


# Assigns each pixel to the given centroids for the algorithm.
# Method finds the closest centroid to the given pixel, then
# assigns that centroids to the pixel.
def assignPixels(centroids):
    clusters = {}

    for x in range(0, img_width):
        for y in range(0, img_height):
            p = px[x, y]
            minClosestCentroid = getClosestCentroid(px[x, y], centroids)

            try:
                clusters[minClosestCentroid].append(p)
            except KeyError:
                clusters[minClosestCentroid] = [p]

    return clusters


# Method is used to  re-center the centroids according
# to the pixels assigned to each. A mean average is 
# applied to each cluster's RGB values, which is then
# set as the new centroids.
def adjustCentroids(clusters):
    new_centroids = []
    keys = sorted(clusters.keys())

    for k in keys:
        n = numpy.mean(clusters[k], axis=0)
        new = (int(n[0]), int(n[1]), int(n[2]))
        print(str(k) + ": " + str(new))
        new_centroids.append(new)

    return new_centroids


# Used to initialize the k-means clustering
def startKmeans(someK):
    centroids = []
    old_centroids = []
    i = 1

    # Initializes someK number of centroids for the clustering
    for k in range(0, someK):
        cent = px[numpy.random.randint(0, img_width), numpy.random.randint(0, img_height)]
        centroids.append(cent)

    print("Random centroids initialized.")

    while not converged(centroids, old_centroids) and i <= 100:
        print("Iteration #" + str(i))
        i += 1

        old_centroids = centroids  # Make the current centroids into the old centroids
        clusters = assignPixels(centroids)  # Assign each pixel in the image to their respective centroids
        centroids = adjustCentroids(clusters)  # Adjust the centroids to the center of their assigned pixels
    print(centroids)
    return centroids


# Once the k-means clustering is finished, this method
# generates the segmented image and opens it.
def drawNewImage(result):
    img = Image.new('RGB', (img_width, img_height), "white")
    p = img.load()

    for x in range(img.size[0]):
        for y in range(img.size[1]):
            RGB_value = result[getClosestCentroid(px[x, y], result)]
            p[x, y] = RGB_value

    img.save(output_image)
    img.show()


num_input = str(input("Enter image number: "))
k_input = int(input("Enter K value: "))

img = "img/test" + num_input.zfill(1) + ".jpg"
output_image = "results/test" + num_input.zfill(1) + "result.jpg"
im = Image.open(img)
img_width, img_height = im.size
px = im.load()

result = startKmeans(k_input)
drawNewImage(result)
