using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace Poc_Template_Core_Test.Helper
{
    [ExcludeFromCodeCoverage]
    public abstract class ModelTest<T>
    {
        protected object[] ComplextTypes { get; set; } = null;

        protected virtual object[] SetComplexTypesToConstructor()
        {
            return null;
        }

        [Fact]
        public void DeveAvaliarConstrutor()
        {
            Type myType = typeof(T);

            var constructorValues = new List<object>();

            this.ComplextTypes = this.SetComplexTypesToConstructor();

            var constructorInfoObj = myType.GetConstructors();
            foreach (var constructor in constructorInfoObj)
            {
                if (constructor.GetParameters().Any())
                {
                    AssertConstructorParams(constructorValues, constructor);
                }
                else
                {
                    AssertConstructorWithoutParams();
                }
            }
        }

        private void AssertConstructorWithoutParams()
        {
            var obj = (T)Activator.CreateInstance(typeof(T));

            var properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
                {
                    property.SetValue(obj, 10);
                    property.GetValue(obj).Should().Be(10);
                }
                else if (property.PropertyType == typeof(string))
                {
                    property.SetValue(obj, "valor");
                    property.GetValue(obj).Should().Be("valor");
                }
                else if (property.PropertyType == typeof(bool) || property.PropertyType == typeof(bool?))
                {
                    property.SetValue(obj, true);
                    property.GetValue(obj).Should().Be(true);
                }
                else if (property.PropertyType == typeof(double) || property.PropertyType == typeof(double?))
                {
                    property.SetValue(obj, 10.1);
                    property.GetValue(obj).Should().Be(10.1);
                }
                else if (property.PropertyType == typeof(long))
                {
                    property.SetValue(obj, (long)12.2);
                    property.GetValue(obj).Should().Be((long)12.2);
                }
                else if (property.PropertyType == typeof(DateTime))
                {
                    property.SetValue(obj, DateTime.Parse("01/02/2021"));
                    property.GetValue(obj).Should().Be(DateTime.Parse("01/02/2021"));
                }
                else if (property.PropertyType == typeof(Guid))
                {
                    property.SetValue(obj, Guid.Parse("09b2821a-2950-4eff-a722-dbc8adf4da55"));
                    property.GetValue(obj).Should().Be(Guid.Parse("09b2821a-2950-4eff-a722-dbc8adf4da55"));
                }
                else if (property.CustomAttributes.Any() && property.CustomAttributes.ElementAt(0) is dynamic)
                {
                    property.SetValue(obj, 11);
                    property.GetValue(obj).Should().Be(11);
                }
                else
                {
                    if (this.ComplextTypes == null)
                    {
                        continue;
                    }

                    var complexType = this.ComplextTypes.FirstOrDefault(x => x.GetType() == property.PropertyType);
                    if (complexType != null)
                    {
                        property.SetValue(obj, complexType);
                        property.GetValue(obj).Should().Be(complexType);
                    }
                }
            }
        }

        private void AssertConstructorParams(List<object> constructorValues, System.Reflection.ConstructorInfo constructor)
        {
            var parameters = constructor.GetParameters();

            foreach (var parameter in parameters)
            {
                if (parameter.ParameterType == typeof(int) || parameter.ParameterType == typeof(int?))
                {
                    constructorValues.Add(10);
                }
                else if (parameter.ParameterType == typeof(bool) || parameter.ParameterType == typeof(bool?))
                {
                    constructorValues.Add(true);
                }
                else if (parameter.ParameterType == typeof(string))
                {
                    constructorValues.Add("valor");
                }
                else if (parameter.ParameterType == typeof(long))
                {
                    constructorValues.Add((long)12.2);
                }
                else if (parameter.ParameterType == typeof(double) || parameter.ParameterType == typeof(double?))
                {
                    constructorValues.Add(10.1);
                }
                else if (parameter.ParameterType == typeof(double?))
                {
                    constructorValues.Add(10.1);
                }
                else if (parameter.ParameterType == typeof(DateTime))
                {
                    constructorValues.Add(DateTime.Parse("01/02/2021"));
                }
                else if (parameter.ParameterType == typeof(Guid))
                {
                    constructorValues.Add(Guid.Parse("09b2821a-2950-4eff-a722-dbc8adf4da55"));
                }
                else if (parameter.CustomAttributes.Any() && parameter.CustomAttributes.ElementAt(0) is dynamic)
                {
                    constructorValues.Add(15);
                }
                else if (parameter.ParameterType == typeof(object))
                {
                    constructorValues.Add(15);
                }
                else
                {
                    if (this.ComplextTypes == null)
                    {
                        continue;
                    }

                    var complexType = this.ComplextTypes.FirstOrDefault(x => x.GetType() == parameter.ParameterType);
                    if (complexType != null)
                    {
                        constructorValues.Add(complexType);
                    }
                }
            }

            var obj = (T)Activator.CreateInstance(typeof(T), constructorValues.ToArray());

            var properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
                {
                    property.GetValue(obj).Should().Be(10);
                }
                else if (property.PropertyType == typeof(bool) || property.PropertyType == typeof(bool?))
                {
                    property.GetValue(obj).Should().Be(true);
                }
                else if (property.PropertyType == typeof(string))
                {
                    property.GetValue(obj).Should().Be("valor");
                }
                else if (property.PropertyType == typeof(double) || property.PropertyType == typeof(double?))
                {
                    property.GetValue(obj).Should().Be(10.1);
                }
                else if (property.PropertyType == typeof(long))
                {
                    property.GetValue(obj).Should().Be((long)12.2);
                }
                else if (property.PropertyType == typeof(DateTime))
                {
                    property.GetValue(obj).Should().Be(DateTime.Parse("01/02/2021"));
                }
                else if (property.PropertyType == typeof(Guid))
                {
                    property.GetValue(obj).Should().Be(Guid.Parse("09b2821a-2950-4eff-a722-dbc8adf4da55"));
                }
                else if (property.CustomAttributes.Any() && property.CustomAttributes.ElementAt(0) is object)
                {
                    property.GetValue(obj).Should().Be(15);
                }
                else if (property.PropertyType == typeof(object))
                {
                    property.GetValue(obj).Should().Be(15);
                }
                else
                {
                    if (this.ComplextTypes == null)
                    {
                        continue;
                    }

                    var complexType = this.ComplextTypes.FirstOrDefault(x => x.GetType() == property.PropertyType);
                    if (complexType != null)
                    {
                        property.GetValue(obj).Should().Be(complexType);
                    }
                }
            }
        }
    }
}
