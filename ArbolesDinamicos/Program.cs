using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolesDinamicos
{
    class Nodo
    {
        public int iValor;
        public List<Nodo> Hijos; //Lista desordenada

        // Constructor del nodo
        public Nodo(int valor)
        {
            iValor = valor;  // Asigna el valor al nodo
            Hijos = new List<Nodo>();  // Inicializa la lista de hijos vacía
        }
    }

    class Arbol
    {
        public Nodo Raiz;  // Nodo raíz del árbol
        private int iContadorNodos = 1;  // Contador para asignar valores secuenciales a los nodos

        // Método para construir el árbol
        public void ConstruirArbol()
        {
            Raiz = new Nodo(iContadorNodos++);  // Crea el nodo raíz con el valor 1
            Console.WriteLine($"Nodo raíz creado con valor: {Raiz.iValor}");  // Muestra el valor del nodo raíz
            ImprimirArbol(Raiz);  // Imprime el árbol en tiempo real
            ConstruirHijos(Raiz);  // Llama al método para construir los hijos del nodo raíz
        }

        // Método recursivo para agregar hijos a un nodo
        private void ConstruirHijos(Nodo nodo)
        {
            Console.Write($"¿Cuántos hijos tendrá el nodo {nodo.iValor}? ");  // Pregunta cuántos hijos tendrá el nodo
            if (int.TryParse(Console.ReadLine(), out int iNumeroHijos) && iNumeroHijos > 0)  // Lee la cantidad de hijos
            {
                for (int i = 0; i < iNumeroHijos; i++)  // Repite para el número de hijos que se desea agregar
                {
                    Nodo hijo = new Nodo(iContadorNodos++);  // Crea un hijo con un valor secuencial
                    nodo.Hijos.Add(hijo);  // Añade el hijo a la lista de hijos del nodo actual
                    //Console.WriteLine($"→ Nodo creado con valor: {hijo.iValor}");  // Muestra el valor del nodo hijo
                    Console.WriteLine("-> Nodo creado con valor: " + hijo.iValor);
                    // Imprime el árbol después de agregar un hijo
                    ImprimirArbol(Raiz);

                    // Llama recursivamente para construir hijos de cada nodo creado
                    ConstruirHijos(hijo);
                }
            }
        }
        
        // Método para imprimir el árbol
        public void ImprimirArbol(Nodo nodo, string sIndentacion = "", bool bEsUltimo = true)
        {
            if (nodo == null) return;  // Si el nodo es nulo, no hacer nada

            Console.Write(sIndentacion);  // Imprime la indentación
            Console.Write(bEsUltimo ? "└── " : "├── ");  // Si es el último hijo, usa un símbolo diferente para la conexión
            Console.WriteLine(nodo.iValor);  // Muestra el valor del nodo

            // Llama recursivamente para imprimir los hijos
            for (int i = 0; i < nodo.Hijos.Count; i++)
            {
                ImprimirArbol(nodo.Hijos[i], sIndentacion + (bEsUltimo ? "    " : "│   "), i == nodo.Hijos.Count - 1);
            }
        }

        // Recorrido en Preorden (Raíz, Izquierda, Derecha)
        public void Preorden(Nodo nodo)
        {
            if (nodo == null) return;  // Si el nodo es nulo, no hacer nada
            Console.Write(nodo.iValor + " ");  // Imprime el valor del nodo
            foreach (var hijo in nodo.Hijos)  // Recorre los hijos del nodo
            {
                Preorden(hijo);  // Llama recursivamente para recorrer los hijos
            }
        }

        // Recorrido en Inorden (Izquierda, Raíz, Derecha) - asumiendo un árbol binario
        public void Inorden(Nodo nodo)
        {
            if (nodo == null) return;  // Si el nodo es nulo, no hacer nada
            if (nodo.Hijos.Count > 0) Inorden(nodo.Hijos[0]);  // Recorrer el hijo izquierdo (primer hijo)
            Console.Write(nodo.iValor + " ");  // Imprime el valor del nodo
            for (int i = 1; i < nodo.Hijos.Count; i++)  // Recorre los hijos derechos
            {
                Inorden(nodo.Hijos[i]);  // Llama recursivamente para recorrer los hijos derechos
            }
        }

        // Recorrido en Postorden (Izquierda, Derecha, Raíz)
        public void Postorden(Nodo nodo)
        {
            if (nodo == null) return;  // Si el nodo es nulo, no hacer nada
            foreach (var hijo in nodo.Hijos)  // Recorre los hijos del nodo
            {
                Postorden(hijo);  // Llama recursivamente para recorrer los hijos
            }
            Console.Write(nodo.iValor + " ");  // Imprime el valor del nodo después de recorrer a los hijos
        }
    }

    class Programa
    {
        static void Main()
        {
            Arbol arbol = new Arbol();  // Crea una nueva instancia del árbol
            arbol.ConstruirArbol();  // Llama al método para construir el árbol

            Console.WriteLine("\nÁrbol final:");
            arbol.ImprimirArbol(arbol.Raiz);  // Imprime el árbol final después de que se haya construido

            // Muestra el recorrido en Preorden
            Console.WriteLine("\nRecorrido en Preorden:");
            arbol.Preorden(arbol.Raiz);

            // Muestra el recorrido en Inorden
            Console.WriteLine("\nRecorrido en Inorden:");
            arbol.Inorden(arbol.Raiz);

            // Muestra el recorrido en Postorden
            Console.WriteLine("\nRecorrido en Postorden:");
            arbol.Postorden(arbol.Raiz);
            Console.WriteLine();
        }
    }
}