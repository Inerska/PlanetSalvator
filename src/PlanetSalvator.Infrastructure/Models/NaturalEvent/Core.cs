using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PlanetSalvator.Infrastructure.Models.NaturalEvent
{
    public enum Title { SeaAndLakeIce, SevereStorms, Volcanoes, Wildfires };

    public enum Description { D15ACalvedFromD15InJanuary2016, D15BCalvedFromD15InJanuary2016, Empty };

    public enum TypeEnum { Point };

    public enum Id { ByuIce, Cems, Eo, Gdacs, Idc, InciWeb, Jtwc, Mbfire, NasaDisp, Natice, Pdc, ReliefWeb, SiVolcano };

    public partial class NaturalEvent
    {
        public static NaturalEvent FromJson(string json) => JsonConvert.DeserializeObject<NaturalEvent>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this NaturalEvent self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new()
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TitleConverter.Singleton,
                DescriptionConverter.Singleton,
                TypeEnumConverter.Singleton,
                IdConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class TitleConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Title) || t == typeof(Title?);

        public override object ReadJson(JsonReader reader, Type t, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Sea and Lake Ice":
                    return Title.SeaAndLakeIce;
                case "Severe Storms":
                    return Title.SevereStorms;
                case "Volcanoes":
                    return Title.Volcanoes;
                case "Wildfires":
                    return Title.Wildfires;
            }
            throw new Exception("Cannot unmarshal type Title");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Title)untypedValue;
            switch (value)
            {
                case Title.SeaAndLakeIce:
                    serializer.Serialize(writer, "Sea and Lake Ice");
                    return;
                case Title.SevereStorms:
                    serializer.Serialize(writer, "Severe Storms");
                    return;
                case Title.Volcanoes:
                    serializer.Serialize(writer, "Volcanoes");
                    return;
                case Title.Wildfires:
                    serializer.Serialize(writer, "Wildfires");
                    return;
            }
            throw new Exception("Cannot marshal type Title");
        }

        public static readonly TitleConverter Singleton = new TitleConverter();
    }

    internal class DescriptionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Description) || t == typeof(Description?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return Description.Empty;
                case "D15A calved from D15 in January 2016.":
                    return Description.D15ACalvedFromD15InJanuary2016;
                case "D15B calved from D15 in January 2016.":
                    return Description.D15BCalvedFromD15InJanuary2016;
            }
            throw new Exception("Cannot unmarshal type Description");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Description)untypedValue;
            switch (value)
            {
                case Description.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case Description.D15ACalvedFromD15InJanuary2016:
                    serializer.Serialize(writer, "D15A calved from D15 in January 2016.");
                    return;
                case Description.D15BCalvedFromD15InJanuary2016:
                    serializer.Serialize(writer, "D15B calved from D15 in January 2016.");
                    return;
            }
            throw new Exception("Cannot marshal type Description");
        }

        public static readonly DescriptionConverter Singleton = new DescriptionConverter();
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Point")
            {
                return TypeEnum.Point;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            if (value == TypeEnum.Point)
            {
                serializer.Serialize(writer, "Point");
                return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }

    internal class IdConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Id) || t == typeof(Id?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "BYU_ICE":
                    return Id.ByuIce;
                case "CEMS":
                    return Id.Cems;
                case "EO":
                    return Id.Eo;
                case "GDACS":
                    return Id.Gdacs;
                case "IDC":
                    return Id.Idc;
                case "InciWeb":
                    return Id.InciWeb;
                case "JTWC":
                    return Id.Jtwc;
                case "MBFIRE":
                    return Id.Mbfire;
                case "NASA_DISP":
                    return Id.NasaDisp;
                case "NATICE":
                    return Id.Natice;
                case "PDC":
                    return Id.Pdc;
                case "ReliefWeb":
                    return Id.ReliefWeb;
                case "SIVolcano":
                    return Id.SiVolcano;
            }
            throw new Exception("Cannot unmarshal type Id");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Id)untypedValue;
            switch (value)
            {
                case Id.ByuIce:
                    serializer.Serialize(writer, "BYU_ICE");
                    return;
                case Id.Cems:
                    serializer.Serialize(writer, "CEMS");
                    return;
                case Id.Eo:
                    serializer.Serialize(writer, "EO");
                    return;
                case Id.Gdacs:
                    serializer.Serialize(writer, "GDACS");
                    return;
                case Id.Idc:
                    serializer.Serialize(writer, "IDC");
                    return;
                case Id.InciWeb:
                    serializer.Serialize(writer, "InciWeb");
                    return;
                case Id.Jtwc:
                    serializer.Serialize(writer, "JTWC");
                    return;
                case Id.Mbfire:
                    serializer.Serialize(writer, "MBFIRE");
                    return;
                case Id.NasaDisp:
                    serializer.Serialize(writer, "NASA_DISP");
                    return;
                case Id.Natice:
                    serializer.Serialize(writer, "NATICE");
                    return;
                case Id.Pdc:
                    serializer.Serialize(writer, "PDC");
                    return;
                case Id.ReliefWeb:
                    serializer.Serialize(writer, "ReliefWeb");
                    return;
                case Id.SiVolcano:
                    serializer.Serialize(writer, "SIVolcano");
                    return;
            }
            throw new Exception("Cannot marshal type Id");
        }

        public static readonly IdConverter Singleton = new IdConverter();
    }
}
