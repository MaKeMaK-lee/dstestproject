using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dstestproject.Storage.Entity
{
    [Table("tblWeatherElements")]
    public class WeatherElement : IUniqueIdenifiableEntity
    {
        [Key]
        [Required]
        [Column("gId")]
        public Guid Id { get; set; }

        [Required]
        [Column("dtDate")]
        public DateTime Date { get; set; }

        [Required]
        [Column("tintTemperatureInteger", TypeName = "tinyint")]
        public sbyte TemperatureInteger { get; set; }

        [Required]
        [Column("tintTemperatureFractional", TypeName = "tinyint")]
        public sbyte TemperatureFractional { get; set; }

        [Required]
        [Column("tintHumidityInteger", TypeName = "tinyint")]
        public sbyte HumidityInteger { get; set; }

        [Required]
        [Column("tintHumidityFractional", TypeName = "tinyint")]
        public sbyte HumidityFractional { get; set; }

        [Required]
        [Column("tintDewPointInteger", TypeName = "tinyint")]
        public sbyte DewPointInteger { get; set; }

        [Required]
        [Column("tintDewPointFractional", TypeName = "tinyint")]
        public sbyte DewPointFractional { get; set; }

        [Required]
        [Column("sintPressure", TypeName = "smallint")]
        public short Pressure { get; set; }
        
        [MaxLength(100)]
        [Required]
        [Column("szWindDirection", TypeName = "nvarchar")]
        public string WindDirections { get; set; }

        [Required]
        [Column("tintWindSpeedInteger", TypeName = "tinyint")]
        public sbyte WindSpeedInteger { get; set; }

        [Required]
        [Column("tintWindSpeedFractional", TypeName = "tinyint")]
        public sbyte WindSpeedFractional { get; set; }

        [Required]
        [Column("tintСloudy", TypeName = "tinyint")]
        public sbyte Cloudy { get; set; }

        [Required]
        [Column("sintCloudHeight", TypeName = "smallint")]
        public short CloudHeight { get; set; }

        [Required]
        [Column("tintHorizontalVisibilityInteger", TypeName = "tinyint")]
        public sbyte HorizontalVisibilityInteger { get; set; }

        [Required]
        [Column("tintHorizontalVisibilityFractional", TypeName = "tinyint")]
        public sbyte HorizontalVisibilityFractional { get; set; }

        [MaxLength(500)]
        [Required]
        [Column("szWeatherPhenomenon", TypeName = "nvarchar")]
        public string WeatherPhenomenon { get; set; }

    }
}