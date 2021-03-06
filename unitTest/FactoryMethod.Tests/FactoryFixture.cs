﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticalPatterns.FactoryMethod;

namespace PracticalPatterns.FactoryMethod.Tests
{
    [TestClass]
    public class FactoryFixture
    {
        [TestMethod]
        public void CreateInstance()
        {
            var factory = new Factory()
            .RegisterType<IFruit, Apple>()
            .RegisterType<IFruit, Orange>("o")
            .RegisterType<IVehicle, Bicycle>()
            .RegisterType<IVehicle, Bicycle>("a")
            .RegisterType<IVehicle, Train>("b")
            .RegisterType<IVehicle, Car>("c");

            Assert.IsInstanceOfType(factory.Create<IFruit>(), typeof(Apple));
            Assert.IsInstanceOfType(factory.Create<IFruit>("o"), typeof(Orange));

            Assert.IsInstanceOfType(factory.Create<IVehicle>(), typeof(Bicycle));
            Assert.IsInstanceOfType(factory.Create<IVehicle>("a"), typeof(Bicycle));
            Assert.IsInstanceOfType(factory.Create<IVehicle>("b"), typeof(Train));
            Assert.IsInstanceOfType(factory.Create<IVehicle>("c"), typeof(Car));
        }
    }
}
