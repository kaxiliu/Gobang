//Pocision para coordenadas
public struct Posicion
{
    public int fila;
    public int columna;


    public Posicion(int fila, int columna)
    {
        this.fila = fila;
        this.columna = columna;
    }

    public int getFila() { return fila; }
    public int getColumna() { return columna; }

    public override bool Equals(object obj)
    {
        return obj is Posicion posicion &&
               fila == posicion.fila &&
               columna == posicion.columna;
    }

    public override string ToString()
    {
        return fila+","+columna;
    }
}

