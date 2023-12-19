def bubble_sort(tab):
    isSorted = False
    while not isSorted:
        isSorted = True
        for index in range(1,len(tab)):
            if tab[index] < tab[index - 1]:
                tampon = tab[index - 1]
                tab[index- 1] = tab[index]
                tab[index] = tampon
                isSorted = False

    return tab

tab = [2,4,1,9,4,2,3]

print(bubble_sort(tab))