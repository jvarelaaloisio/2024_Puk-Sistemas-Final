using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABB : ABBTDA
{
    NodoABB raiz;

    public int Raiz()
    {
        return raiz.info;
    }

    public bool ArbolVacio()
    {
        return (raiz == null);
    }

    public void InicializarArbol()
    {
        raiz = null;
    }

    public ABBTDA HijoDer()
    {
        return raiz.hijoDer;
    }

    public ABBTDA HijoIzq()
    {
        return raiz.hijoIzq;
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
        else if (raiz.info > x)
        {
            raiz.hijoIzq.AgregarElem(x);
        }
        else if (raiz.info < x)
        {
            raiz.hijoDer.AgregarElem(x);
        }
    }

    public void EliminarElem(int x)
    {
        if (raiz != null)
        {
            if (raiz.info == x && raiz.hijoIzq.ArbolVacio() && raiz.hijoDer.ArbolVacio())
            {
                raiz = null;
            }
            else if (raiz.info == x && !raiz.hijoIzq.ArbolVacio())
            {
                raiz.info = this.mayor(raiz.hijoIzq);
                raiz.hijoIzq.EliminarElem(raiz.info);
            }
            else if (raiz.info == x && raiz.hijoIzq.ArbolVacio())
            {
                raiz.info = this.menor(raiz.hijoDer);
                raiz.hijoDer.EliminarElem(raiz.info);
            }
            else if (raiz.info < x)
            {
                raiz.hijoDer.EliminarElem(x);
            }
            else
            {
                raiz.hijoIzq.EliminarElem(x);
            }
        }
    }

    public int mayor(ABBTDA a)
    {
        if (a.HijoDer().ArbolVacio())
        {
            return a.Raiz();
        }
        else
        {
            return mayor(a.HijoDer());
        }
    }

    public int menor(ABBTDA a)
    {
        if (a.HijoIzq().ArbolVacio())
        {
            return a.Raiz();
        }
        else
        {
            return menor(a.HijoIzq());
        }
    }
}
