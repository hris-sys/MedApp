namespace MedAppDataAccess.Models
{
    public class MedicineActiveIngredient
    {
        public int ActiveIngredientId { get; set; }

        public ActiveIngredient ActiveIngredient { get; set; }

        public int MedicineId { get; set; }

        public Medicine Medicine { get; set; }
    }
}
