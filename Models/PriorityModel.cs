using Insight.Database;

namespace ParentChildsIssueReproduction.Models
{
    public class PriorityModel
    {
        [RecordId]
        public int Id { get; set; }

        [ParentRecordId]
        public int? ParentId { get; set; }
        public int IndexNumber { get; set; }

        [Column(SerializationMode = SerializationMode.Json)]
        public required IEnumerable<LocalizedNameModel> Name { get; set; }

        [ChildRecords]
        public IList<PriorityModel>? Children { get; set; }
    }
}