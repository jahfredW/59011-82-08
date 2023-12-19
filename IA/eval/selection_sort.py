def selection_sort(tab):
    for index in range(len(tab)):
        for j in range(index + 1, len(tab)):
            if tab[j] <= tab[index]:
                tampon = tab[index]
                tab[index] = tab[j]
                tab[j] = tampon
    return tab

tab = [2,4,6,9,4,2,3,1,3]

print(selection_sort(tab))