using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(Example.Business.AutoMapperConfig), "Execute")]

namespace Example.Business
{

    public interface IMapFrom<T> { } // Class that implements it declares FROM which object will be mapped

    public interface IMapTo<T> { } // Class that implements it declares TO which object will be mapped

    // In case complex mapping is required through this option you
    // can create custom mapping rules
    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }


    public class AutoMapperConfig
    {
        /// <summary>
        /// Initialize Mapping process by finding all types that needs
        /// to be mapped
        /// </summary>
        public static void Execute()
        {
            var types = Assembly.GetExecutingAssembly().GetExportedTypes();

            Mapper.Initialize(cfg =>
            {
                cfg.AllowNullDestinationValues = false;
            });

            RegisterStandardMappings(types);
            RegisterReverseMappings(types);
            ReverseCustomMappings(types);
        }

        /// <summary>
        /// Load all types that implement interface <see cref="IMapFrom{T}"/>
        /// and create a map between {T} and them
        /// </summary>
        /// <param name="types"></param>
        private static void RegisterStandardMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)
                              && !t.IsAbstract
                              && !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();

            foreach (var map in maps)
            {

                Mapper.CreateMap(map.Source, map.Destination);

            }
        }

        /// <summary>
        /// Load all types that implement interface <see cref="IMapFrom{T}"/>
        /// and create a map between them and {T}
        /// </summary>
        /// <param name="types"></param>
        private static void RegisterReverseMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>)
                              && !t.IsAbstract
                              && !t.IsInterface
                        select new
                        {
                            Source = t,
                            Destination = i.GetGenericArguments()[0]
                        }).ToArray();

            foreach (var map in maps)
            {
                Mapper.CreateMap(map.Source, map.Destination);
            }
        }

        /// <summary>
        /// Load all types that implement interface <see cref="IHaveCustomMappings"/>
        /// and register their mapping
        /// </summary>
        /// <param name="types"></param>
        private static void ReverseCustomMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t)
                              && !t.IsAbstract
                              && !t.IsInterface
                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                map.CreateMappings(Mapper.Configuration);
            }
        }
    }
}
