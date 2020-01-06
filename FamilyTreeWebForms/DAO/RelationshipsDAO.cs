using FamilyTreeWebForms.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyTreeWebForms.DAO
{
    public class RelationshipsDAO
    {
        FamilyTreeEntities context;

        public RelationshipsDAO()
        {
            this.context = new FamilyTreeEntities();
        }

        public RelationshipsDAO(FamilyTreeEntities context)
        {
            this.context = context;
        }

        public void createRelationship(Relationship relationship)
        {
            this.context.Relationships.Add(relationship);
            context.SaveChanges();
        }

        public void updateRelationship(Relationship persona)
        {
            Relationship updated = this.context.Relationships.FirstOrDefault(p => p.id == persona.id);
            updated.Relationship1 = persona.Relationship1;
            updated.createdAt = persona.createdAt;
            updated.updatedAt = persona.updatedAt;
            context.SaveChanges();
        }

        public List<Relationship> getRelationships()
        {
            return this.context.Relationships.ToList();
        }

        public Relationship getRelationshipById(int id)
        {
            return this.context.Relationships.FirstOrDefault(p => p.id == id);
        }

        public void deleteRelationship(int relationshipId)
        {
            Relationship relationship = this.getRelationshipById(relationshipId);
            if(relationship!= null)
            {
                if(this.context.Relatives.Any(r => r.RelationshipId == relationship.id))
                {
                    throw new Exception("Cannot delete relationship because there are relatives registered with this type of relationship");
                }
                this.context.Relationships.Remove(relationship);
                context.SaveChanges();
            }
        }
    }
}