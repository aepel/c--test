using Newtonsoft.Json;
using Qualyt.Domain.Models.FormTemplates;
using Qualyt.Domain.Models.Interfaces;
using Qualyt.Domain.Models.Laboratories.Enums;
using Qualyt.Domain.Models.MedicalTreatments;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Qualyt.Domain.Models.Laboratories
{
    public class Product:IAuditableEntity,IFormTemplate
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public bool Active { get; set; }
        public ProductType ProductType { get; set; }
        public long LaboratoryId { get; set; }
        public Laboratory Laboratory { get; set; }
        public long Amount { get; set; }
        public string Code {
            get
            {
                var words = Name.Replace("(", "").Replace(")", "").Split(' ');
                var initials = words.Select(x => new Initial() { Start = x.FirstOrDefault(), Sufix = new string(x.Skip(1).ToArray()) }).ToList();
                string code="";
                if (initials.Count() >= 3)
                    code= new string(initials.Select(x => x.Start).Take(3).ToArray());
                else
                {
                    var neededChars = 3 - initials.Count();
                    initials.Reverse();
                    foreach(var initial in initials)
                    {
                        var availableChars = initial.Sufix.Count();
                        if (neededChars <= availableChars)
                        {
                            code = initial.Start + new string(initial.Sufix.Take(neededChars).ToArray()) + code;
                            neededChars = 0;
                        }
                        else
                        {
                            code = initial.Start + new string(initial.Sufix.Take(availableChars).ToArray()) + code;
                            neededChars -= availableChars;
                        }
                    }
                }
                code=code.PadRight(3, '#');
                return code +"-"+ Id.ToString().PadLeft(4,'0');
            }
        }
        [NotMapped]
        public List<Field> Fields { get; set; }
        public string SerializedFields
        {
            get
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                return JsonConvert.SerializeObject(Fields, settings);
            }
            set
            {
                if (value != null)
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    };
                    Fields = JsonConvert.DeserializeObject<List<Field>>(value, settings);
                }
            }
        }
    }
}

public class Initial
{
    public char Start { get; set; }
    public string Sufix { get; set; }
}