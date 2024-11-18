using Enemies;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class ABB : IABBTDA
{
    private NodoABB raiz;

    public int Raiz()
    {
        return raiz.info;
    }

    public bool ArbolVacio()
    {
        return raiz == null;
    }

    public void InicializarArbol()
    {
        raiz = null;
    }

    public IABBTDA HijoIzq()
    {
        return raiz.hijoIzq;
    }

    public IABBTDA HijoDer()
    {
        return raiz.hijoDer;
    }

    public void AgregarElem(int x)
    {
        if (raiz == null)
        {
            raiz = new NodoABB();
            raiz.info = x;
            raiz.hijoIzq = new ABB();
            raiz.hijoIzq.InicializarArbol();
            raiz.hijoDer = new ABB();
            raiz.hijoDer.InicializarArbol();
        }
        else if (x < raiz.info)
        {
            raiz.hijoIzq.AgregarElem(x);
        }
        else if (x > raiz.info)
        {
            raiz.hijoDer.AgregarElem(x);
        }
        Balance();
    }

    public void EliminarElem(int x)
    {
        if (raiz == null) return;

        if (x < raiz.info)
        {
            raiz.hijoIzq.EliminarElem(x);
        }
        else if (x > raiz.info)
        {
            raiz.hijoDer.EliminarElem(x);
        }
        else
        {
            if (raiz.hijoIzq.ArbolVacio() && raiz.hijoDer.ArbolVacio())
            {
                raiz = null;
            }
            else if (!raiz.hijoIzq.ArbolVacio())
            {
                raiz.info = ((ABB)raiz.hijoIzq).FindMax();
                raiz.hijoIzq.EliminarElem(raiz.info);
            }
            else
            {
                raiz.info = ((ABB)raiz.hijoDer).FindMin();
                raiz.hijoDer.EliminarElem(raiz.info);
            }
        }
        Balance();
    }

    private void Balance()
    {
        int balance = BalanceFactor();

        if (balance > 1)
        {
            if (HijoIzq().BalanceFactor() >= 0)
            {
                RotacionDerecha();
            }
            else
            {
                HijoIzq().RotacionIzquierda();
                RotacionDerecha();
            }
        }
        else if (balance < -1)
        {
            if (HijoDer().BalanceFactor() <= 0)
            {
                RotacionIzquierda();
            }
            else
            {
                HijoDer().RotacionDerecha();
                RotacionIzquierda();
            }
        }
    }

    public int Altura()
    {
        if (ArbolVacio())
            return 0;
        return 1 + Mathf.Max(HijoIzq().Altura(), HijoDer().Altura());
    }

    public int BalanceFactor()
    {
        if (ArbolVacio())
            return 0;
        return HijoIzq().Altura() - HijoDer().Altura();
    }

    public void RotacionIzquierda()
    {
        if (raiz == null || raiz.hijoDer.ArbolVacio())
            return;

        NodoABB nuevaRaiz = ((ABB)raiz.hijoDer).raiz;
        raiz.hijoDer = nuevaRaiz.hijoIzq;
        nuevaRaiz.hijoIzq = this;

        raiz = nuevaRaiz;
    }

    public void RotacionDerecha()
    {
        if (raiz == null || raiz.hijoIzq.ArbolVacio())
            return;

        NodoABB nuevaRaiz = ((ABB)raiz.hijoIzq).raiz;
        raiz.hijoIzq = nuevaRaiz.hijoDer;
        nuevaRaiz.hijoDer = this;

        raiz = nuevaRaiz;
    }

    public int FindMax()
    {
        if (ArbolVacio())
            throw new System.Exception("Tree is empty.");
        if (HijoDer().ArbolVacio())
            return Raiz();
        return ((ABB)HijoDer()).FindMax();
    }

    public int FindMin()
    {
        if (ArbolVacio())
            throw new System.Exception("Tree is empty.");
        if (HijoIzq().ArbolVacio())
            return Raiz();
        return ((ABB)HijoIzq()).FindMin();
    }
}
