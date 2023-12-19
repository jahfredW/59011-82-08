def insertion_sort(tab):
    for index in range(1,len(tab)):
        cle = tab[index]
        j = index - 1
        while j >= 0 and tab[j] > cle:
            # décaler vers la droite 
            tab[j + 1] = tab[j]
            j = j - 1
        tab[j + 1] = cle

    return tab

tab = [2,4,6,9,4,2,3,1,3]

print(insertion_sort(tab))