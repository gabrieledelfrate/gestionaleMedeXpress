using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace gestionaleMedeXpress.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("utente")]
        public string Utente { get; set; } = null!;

        [BsonElement("prodotti")]
        public List<Prodotto> Prodotti { get; set; } = null!;

        [BsonElement("totale")]
        public string Totale { get; set; } = null!;

        [BsonElement("data")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Data { get; set; }
    }

    public class Prodotto
    {
        [BsonElement("minSan")]
        public int MinSan { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; } = null!;

        [BsonElement("prezzo")]
        public double Prezzo { get; set; }

        [BsonElement("quantita")]
        public int Quantita { get; set; }
    }
}
