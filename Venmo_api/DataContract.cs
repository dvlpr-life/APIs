using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Venmo
{
    [DataContract]
    class APIResult
    {
        [DataMember(Name = "paging")] public Paging Paging { get; set; }
        [DataMember(Name = "data")] public IList<Data> Data { get; set; }
    }

    [DataContract]
    class Paging
    {
        [DataMember(Name = "next")] public string Next { get; set; }
        [DataMember(Name = "previous")] public string Previous { get; set; }
    }

    [DataContract]
    class Data
    {
        [DataMember(Name = "payment_id")] public string Payment_ID { get; set; }
        [DataMember(Name = "permalink")] public string Permalink { get; set; }
        [DataMember(Name = "via")] public string Via { get; set; }
        [DataMember(Name = "action_links")] public ActionLink Action_Links { get; set; }
        [DataMember(Name = "story_id")] public string Story_ID { get; set; }
        [DataMember(Name = "updated_time")] public string Updated_Time { get; set; }
        [DataMember(Name = "audience")] public string Audience { get; set; }
        [DataMember(Name = "created_time")] public string Created_Time { get; set; }
        //"comments": [],
        //"mentions": [],
        [DataMember(Name = "message")] public string Message { get; set; }
        [DataMember(Name = "type")] public string type { get; set; }
        [DataMember(Name = "actor")] public Actor Actor { get; set; }
        [DataMember(Name = "transactions")] public IList<Transaction> Transactions { get; set; }
    }

    [DataContract]
    class Actor
    {
        [DataMember(Name = "username")] public string UserName { get; set; }
        [DataMember(Name = "picture")] public string Picture { get; set; }
        [DataMember(Name = "is_business")] public string Is_Business { get; set; }
        [DataMember(Name = "name")] public string Name { get; set; }
        [DataMember(Name = "firstname")] public string FirstName { get; set; }
        [DataMember(Name = "lastname")] public string LastName { get; set; }
        [DataMember(Name = "cancelled")] public string Cancelled { get; set; }
        [DataMember(Name = "date_created")] public string Date_Created { get; set; }
        [DataMember(Name = "external_id")] public string External_ID { get; set; }
        [DataMember(Name = "id")] public string ID { get; set; }
    }

    [DataContract]
    class Transaction
    {
        [DataMember(Name = "target")] public Actor Target { get; set; }
    }

    [DataContract]
    class ActionLink
    {
        [DataMember(Name = "iphone_app_store_id")] public string iPhone_App_Store_ID { get; set; }
        [DataMember(Name = "iphone_app_store_link_text")] public string iPhone_App_Store_Link_Text { get; set; }
    }
}