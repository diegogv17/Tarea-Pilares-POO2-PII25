using static Tarea___Pilares_POO.NewFolder.mini_e_commerce;

Cliente cliente1 = new Cliente("Diego Gómez", "diego@email.com");

Carrito carrito1 = new Carrito();
carrito1.AgregarProducto(new ProductoFisico("Laptop", 5000, "Electrónica"));
carrito1.AgregarProducto(new ProductoDigital("Curso de C#", 300, "Educación"));

Orden orden1 = new Orden(cliente1, carrito1);
orden1.ResumenOrden();

IPago pago = new PagoConTarjeta(7867647454455, 5467);
pago.ProcesarPago();
