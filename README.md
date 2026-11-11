# Colmado - Sistema de consola en C#

Evaluación 06 de Fundamentos de Programación (TDS-002), ITLA.

## Integrantes

- Darieli Alexandra Báez Rosario - 2026-0700
- Jade Mariel Mateo Báez - 2026-0706
- Joycel Otoniel Pérez Nieves - 2026-0703
- Miguel Angel Polonia Paredes - 2026-0719

## Descripción

Sistema de consola para un colmado. Tiene un menú que se repite hasta que el usuario elige salir:

1. Ver productos: muestra la lista con código, nombre y precio.
2. Agregar a la compra: se escribe el código y la cantidad, y se va sumando al subtotal.
3. Ver factura: muestra la cantidad de artículos, el subtotal, el ITBIS (18 %) y el total.
4. Pagar: pide con cuánto paga el cliente, calcula la devuelta y empieza una compra nueva.
0. Salir.

Las entradas se validan con TryParse, así que si se escribe una letra en vez de un número el programa vuelve a pedir el dato y no se cae.

## Métodos

- `MostrarMenu()` y `MostrarProductos()`: muestran información en pantalla.
- `ObtenerNombre(int codigo)` y `ObtenerPrecio(int codigo)`: reciben el código y devuelven el nombre o el precio.
- `CalcularItbis(double monto)`: devuelve el ITBIS de un monto.
- `MostrarFactura(int articulos, double subtotal)`: imprime la factura.
- `LeerEntero(string mensaje)` y `LeerDecimal(string mensaje)`: piden un número y lo validan con TryParse.

## Cómo ejecutarlo

Hace falta tener instalado el .NET SDK 10.

```
git clone https://github.com/otoningo/colmado-fp.git
cd colmado-fp
dotnet run
```
