using System.Drawing;

namespace NaveEspacial
{
    internal class Ventana
    {
        public int Ancho { get; set; }
        public int Altura { get; set; }
        public ConsoleColor Color { get; set; }
        public Point LimiteSuperior { get; set; }
        public Point LimiteInferior { get; set; }

        public Ventana(int ancho, int altura, ConsoleColor color, Point limiteInferior, Point limiteSuperior)
        {
            Ancho = ancho;
            Altura = altura;
            Color = color;
            LimiteInferior = limiteInferior;
            LimiteSuperior = limiteSuperior;
            Init();
        }

        private void Init()
        {
            int maxAncho = Console.LargestWindowWidth;
            int maxAltura = Console.LargestWindowHeight;

            if (Ancho > maxAncho) Ancho = maxAncho;
            if (Altura > maxAltura) Altura = maxAltura;

            // Primero ajusta el buffer
            Console.SetBufferSize(Ancho, Altura);

            // Luego ajusta la ventana
            Console.SetWindowSize(Ancho, Altura);

            Console.Title = "NAVE";
            Console.BackgroundColor = Color;

            Console.Clear();
            Console.SetCursorPosition(0, 0);
        }


        public void DibujarMarco()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            // Línea superior
            for (int x = LimiteSuperior.X; x <= LimiteInferior.X; x++)
            {
                Console.SetCursorPosition(x, LimiteSuperior.Y);
                Console.Write("═");
            }

            // Línea inferior
            for (int x = LimiteSuperior.X; x <= LimiteInferior.X; x++)
            {
                Console.SetCursorPosition(x, LimiteInferior.Y);
                Console.Write("═");
            }

            // Lados
            for (int y = LimiteSuperior.Y; y <= LimiteInferior.Y; y++)
            {
                Console.SetCursorPosition(LimiteSuperior.X, y);
                Console.Write("║");

                Console.SetCursorPosition(LimiteInferior.X, y);
                Console.Write("║");
            }

            // Esquinas
            Console.SetCursorPosition(LimiteSuperior.X, LimiteSuperior.Y);
            Console.Write("╔");

            Console.SetCursorPosition(LimiteInferior.X, LimiteSuperior.Y);
            Console.Write("╗");

            Console.SetCursorPosition(LimiteSuperior.X, LimiteInferior.Y);
            Console.Write("╚");

            Console.SetCursorPosition(LimiteInferior.X, LimiteInferior.Y);
            Console.Write("╝");
        }
    }
}
