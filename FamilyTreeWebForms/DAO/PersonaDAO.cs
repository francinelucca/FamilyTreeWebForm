using FamilyTreeWebForms.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyTreeWebForms.DAO
{
    public class PersonaDAO
    {
        FamilyTreeEntities context;

        public PersonaDAO()
        {
            this.context = new FamilyTreeEntities();
        }

        public PersonaDAO(FamilyTreeEntities context)
        {
            this.context = context;
        }

        public void createPersona (Persona persona)
        {
            this.context.Personas.Add(persona);
            context.SaveChanges();
        }

        public void updatePersona(Persona persona)
        {
            Persona updated = this.context.Personas.FirstOrDefault(p => p.id == persona.id);
            updated.FirstName = persona.FirstName;
            updated.LastName = persona.LastName;
            updated.Gender = persona.Gender;
            updated.BirthDay = persona.BirthDay;
            updated.createdAt = persona.createdAt;
            updated.updatedAt = persona.updatedAt;
            context.SaveChanges();
        }

        public List<Persona> getPersonas()
        {
            return this.context.Personas.ToList();
        }

        public Persona getPersonaById(int id)
        {
            return this.context.Personas.FirstOrDefault(p => p.id == id);
        }

        public void deletePersona(int id)
        {
            Persona persona = this.getPersonaById(id);
            if(persona!= null)
            {
                if(this.context.Relatives.Any(r => r.RelativeId == persona.id))
                {
                    throw new Exception("Cannot delete persona because it is registered as a relative to other personas'");
                }
                this.context.Relatives.RemoveRange(persona.Relatives);
                this.context.Personas.Remove(persona);
                context.SaveChanges();
            }
        }
    }
}