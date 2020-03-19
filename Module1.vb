Module Module1

    ' Fonction Prenant en Paramètre une Chaîne de Caractère donnée et
    ' Retourner une chaîne contenant Bonjour et la chaîne entrée
    Function Bonjour(chaine As String) As String
        Return "Bonjour à vous " & chaine
    End Function

    ' Fonction Prenant en Paramètre deux Nombres et Retournant leur Somme
    Function Somme(a As Integer, b As Integer) As Integer
        Return a + b
    End Function

    ' Fonction Récursive permettant de Calculer le Factorielle d'un Nombre Entré par l'utilisateur
    Function factorielle(n As Integer) As Integer
        If (n = 0 Or n = 1) Then
            Return 1
        ElseIf n > 1 Then
            Return n * factorielle(n - 1)
        End If
        Return 0
    End Function
    Const limite = 11
    ' Fonction permettant d'initialiser un tableau avec des valeurs aléatoires
    Function init() As Array
        Dim Tab(limite) As Integer
        Randomize()
        For i As Integer = 0 To limite
            Tab(i) = Rnd(1) * 100
        Next
        Return Tab
    End Function
    ' Procédure Permettant d'afficher les éléments d'un tableau entré en paramètre
    Sub Afficher(T As Array)
        For i As Integer = 0 To T.Length - 1
            Console.Write("| " & T(i) & " |")
        Next
    End Sub
    ' Procédure Permettant de Permuter la valeur de 2 Variables Passés en Paramètre
    Sub Echanger(a As Integer, b As Integer)
        Dim c As Integer
        c = a
        a = b
        b = c
    End Sub
    ' Fonction Permettant de Renvoyer l'indice du Minimum d'un Tableau
    Function RangMin(T As Array, debut As Integer, fin As Integer) As Integer
        Dim Min, Indice As Integer
        Min = T(debut)
        Indice = debut
        For i As Integer = debut To fin
            If T(i) < Min Then
                Min = T(i)
                Indice = i
            End If
        Next
        Return Indice
    End Function
    ' Trier est une Fonction qui prend en entreé un Tableau non vide et renvoie un Tableau Trié
    Function Trier(T As Array) As Array
        Dim A As Array = T
        For i As Integer = 0 To A.Length - 1
            Echanger(A(i), A(RangMin(A, i, A.Length - 1)))
        Next
        Return A
    End Function
    ' Partitionner est une méthode qui subdivise un Tableau selon l'approche du Tri Rapide
    Function Partition(A As Array, p As Integer, r As Integer) As Integer
        Dim x, i As Integer
        x = A(r)
        i = p - 1
        For j As Integer = p To r - 1
            If A(j) <= x Then
                i += 1
                Echanger(A(i), A(j))
            End If
        Next
        Echanger(A(i + 1), A(r))
        Return i + 1
    End Function
    ' Procédure Implémentant le QuickSort
    Sub QuickSort(A As Array, p As Integer, r As Integer)
        Dim q As Integer
        If p < r Then
            q = Partition(A, p, r)
            QuickSort(A, p, q - 1)
            QuickSort(A, q + 1, r)
        End If
    End Sub
    Sub Main()
        Dim a As Char
        Dim nom, bjr As String
        Dim y, nbSomme1, nbSomme2, som, nbFacto, facto, quickDeb, quickFin As Integer
        Dim randomTab, quickTab, tab As Array
        Try
            Console.WriteLine()
            Console.Write("################# Début du Programme #################")
            Console.WriteLine()
            Console.WriteLine()
            Console.Write("*********** Menu Principal *************")
            Console.WriteLine()
            Console.WriteLine("a- Bonjour Personnalisé")
            Console.WriteLine("b- Somme de 2 Nombres")
            Console.WriteLine("c- Calcul du Factoriel d'un Nombre ")
            Console.WriteLine("d- Tri d'un Tableau rempli aléatoirement")
            Console.WriteLine("e- Tri par Segmentation ou Quicksort")
            Console.WriteLine("f- Quitter")
            Console.Write("***********  Fin du Menu   *************")
            Console.WriteLine()
            Console.WriteLine()
            Do
                Console.WriteLine("Faites un Choix en choisissant une lettre ")
                a = Console.ReadLine()
            Loop Until a = "a" Or a = "b" Or a = "c" Or a = "d" Or a = "e" Or a = "f"
            Console.WriteLine()
            Select Case a
                Case "a"
                    Console.Write("******** Bonjour Personnalisé **********")
                    Console.WriteLine()
                    Console.WriteLine("Veuillez Entrer Votre Nom")
                    nom = Console.ReadLine()
                    bjr = Bonjour(nom)
                    Console.WriteLine(bjr)
                    Console.WriteLine()
                    Console.Write("******** Bonjour Personnalisé **********")
                    Console.WriteLine()
                Case "b"
                    Console.Write("*********  Somme de 2 Nombres **********")
                    Console.WriteLine()
                    Do
                        Console.WriteLine("Entrez le Premier Nombre")
                        nbSomme1 = Console.ReadLine()
                    Loop Until IsNumeric(nbSomme1)
                    Do
                        Console.WriteLine("Entrez le Second Nombre")
                        nbSomme2 = Console.ReadLine()
                    Loop Until IsNumeric(nbSomme2)
                    som = Somme(nbSomme1, nbSomme2)
                    Console.WriteLine()
                    Console.WriteLine("Le Résultat est le suivant : " & nbSomme1 & " + " & nbSomme2 & " = " & som)
                    Console.WriteLine()
                    Console.Write("*********  Somme de 2 Nombres **********")
                    Console.WriteLine()
                Case "c"
                    Console.WriteLine()
                    Console.Write("*********  Calcul du Factoriel *********")
                    Console.WriteLine()
                    Console.WriteLine("Veuillez Entrer un Nombre")
                    nbFacto = Console.ReadLine()
                    facto = factorielle(nbFacto)
                    Console.WriteLine()
                    Console.WriteLine(nbFacto & "! = " & facto)
                    Console.WriteLine()
                    Console.Write("*********  Calcul du Factoriel *********")
                    Console.WriteLine()
                Case "d"
                    Console.WriteLine()
                    Console.Write("********* RandomSort *********")
                    Console.WriteLine()
                    Console.WriteLine()
                    randomTab = init()
                    Console.WriteLine("Tableau Généré Aléatoirement par le Programme")
                    Console.WriteLine()
                    Afficher(randomTab)
                    Console.WriteLine()
                    Console.WriteLine("Tableau obtenu Après le RandomSort")
                    Console.WriteLine()
                    tab = Trier(randomTab)
                    Afficher(tab)
                    Console.WriteLine()
                    Console.WriteLine()
                    Console.Write("********* RandomSort *********")
                    Console.WriteLine()
                Case "e"
                    quickDeb = 0
                    quickFin = 11
                    Console.Write("*********  QuickSort **********")
                    Console.WriteLine()
                    quickTab = init()
                    Afficher(quickTab)
                    Console.WriteLine()
                    QuickSort(quickTab, quickDeb, quickFin)
                    Console.WriteLine()
                    Afficher(quickTab)
                    Console.Write("*********  QuickSort **********")
                Case "f"
                    End
                Case Else
                    Randomize()
                    y = (Rnd(1) * 100)
                    Console.WriteLine(y)
            End Select

            Console.WriteLine()
            Console.Write("################## Fin du Programme ##################")
            Console.Read()
        Catch
            Console.WriteLine("Erreur dans le Programme car une exception est rencontrée")
            Console.ReadLine()
        End Try
    End Sub

End Module
