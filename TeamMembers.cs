namespace Final_Project
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TeamMember
    {
        [Key] // Marks the primary key
        public int Id { get; set; } // Primary key

        [Required]
        public string FullName { get; set; }

        [JsonConverter(typeof(DateOnlyConverter))]
        public DateTime Birthdate { get; set; }

        public string CollegeProgram { get; set; }

        public string YearInProgram { get; set; } // E.g., Freshman, Sophomore
    }

    public class DateOnlyConverter : JsonConverter<DateTime>
    {
        private const string DateFormat = "yyyy-MM-dd";

        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString(DateFormat));
        }

        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var dateStr = reader.Value?.ToString();
            return DateTime.TryParseExact(dateStr, DateFormat, null, System.Globalization.DateTimeStyles.None, out var date)
                ? date
                : existingValue;
        }
    }
}
