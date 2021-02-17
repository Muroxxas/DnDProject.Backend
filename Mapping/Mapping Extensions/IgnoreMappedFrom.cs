using AutoMapper;
using DnDProject.Entities.CustomAttributes.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDProject.Backend.Mapping.Mapping_Extensions
{
    public static class IgnoreMappedFrom
    {
        //Prevents destination members with the NotMappedTo attribute from being mapped from.
        public static IMappingExpression<TSource, TDestination> IgnoreNotMapped<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> expression)
        {
            //1. Get an object of type TSource.
            var sourceType = typeof(TSource);

            //2. For each property in TSource...
            foreach( var property in sourceType.GetProperties())
            {
                //3.Get all the attributed that property has been tagged with.
                PropertyDescriptor descriptor = TypeDescriptor.GetProperties(sourceType)[property.Name];

                //4. If a property has been tagged with the NotMappedTo attribute..
                NotMappedFromAttribute attribute = (NotMappedFromAttribute)descriptor.Attributes[typeof(NotMappedFromAttribute)];
                if(attribute != null)
                {
                    //5. Update our expression to ingore that property.
                    expression.ForMember(property.Name, opt => opt.Ignore());
                }

            }
            return expression;
        }
    }
}
