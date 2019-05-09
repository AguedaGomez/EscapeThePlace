public class GameStages
{
    public class Introduction
    {
        public static readonly string SceneName = "Introduction";
        public static readonly int Unseen = 1;
        public static readonly int Completed = 2;
    }

    public class Kitchen
    {
        public static readonly string SceneName = "Kitchen";
        public static readonly int Unseen = 1;
        public static readonly int Completed = 2; // Cambiar por el número de escena que corresponda (armario abierto, caja no interactiva)
    }

    public class Hall
    {
        public static readonly string SceneName = "Hall";
        public static readonly int Unseen = 1;
        public static readonly int Completed = 2; // Cambiar por el número de escena que muestre la recompensa
    }

    public class Entrance
    {
        public static readonly string SceneName = "Entrance";
        public static readonly int Unseen = 1;
        public static readonly int ItemUsed = 2; // Cambiar por el número de escena que corresponda (archivador que al abrir el puzzle ya aparece iluminado, para permitir ir adelante y atrás)
        public static readonly int Completed = 3; // Cambiar por el número de escena que corresponda (pensar qué mostrar)
    }
}
