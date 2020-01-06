using FamilyTreeWebForms.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyTreeWebForms.DAO
{
    public class RelativeDAO
    {
        FamilyTreeEntities context;

        public RelativeDAO()
        {
            this.context = new FamilyTreeEntities();
        }

        public RelativeDAO(FamilyTreeEntities context)
        {
            this.context = context;
        }

        public void createRelative(Relative relative)
        {
            this.context.Relatives.Add(relative);
            context.SaveChanges();
        }

        public void updateRelative(Relative relative)
        {
            Relative updated = this.context.Relatives.FirstOrDefault(p => p.id == relative.id);
            updated.RelativeId = relative.RelativeId;
            updated.PersonaId = relative.PersonaId;
            updated.RelationshipId = relative.RelationshipId;
            updated.createdAt = relative.createdAt;
            updated.updatedAt = relative.updatedAt;
            context.SaveChanges();
        }

        public List<Relative> getRelatives()
        {
            return this.context.Relatives.ToList();
        }

        public Relative getRelativeById(int id)
        {
            return this.context.Relatives.FirstOrDefault(p => p.id == id);
        }

        public void deleteRelative(int relativeID)
        {
            Relative relative = this.getRelativeById(relativeID);
            if (relative != null)
            {
                this.context.Relatives.Remove(relative);
                context.SaveChanges();
            }
        }
    }
}