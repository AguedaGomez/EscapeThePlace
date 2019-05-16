public class GameStages
{
    public class Introduction
    {
        public static readonly string SceneName = "Introduction";
        public static readonly string Unseen = "1";
        public static readonly string Completed = "2";
    }

    public class Kitchen
    {
        public static readonly string SceneName = "Kitchen";
        public static readonly string Unseen = "1";
        public static readonly string Completed = "5"; // open door
    }

    public class Basement
    {
        public static readonly string SceneName = "Basement";
        public static readonly string Unseen = "1";
        public static readonly string ItemUsed = "2"; // Cambiar por el número de escena que corresponda (archivador que al abrir el puzzle ya aparece iluminado, para permitir ir adelante y atrás)
        public static readonly string Completed = "3"; // Cambiar por el número de escena que corresponda (pensar qué mostrar)
    }

    public class Hall
    {
        public static readonly string SceneName = "Hall";
        public static readonly string Unseen = "1";
        public static readonly string Completed = "6"; // Cambiar por el número de escena que muestre la recompensa
    }
}
