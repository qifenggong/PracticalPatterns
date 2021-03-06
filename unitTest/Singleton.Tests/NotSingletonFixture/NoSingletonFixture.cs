﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PracticalPatterns.Singleton.Tests.NotSingletonFixture
{
    class Target { }

    class Client
    {
        static IList<Target> list = new List<Target>();
        Target target;

        public void SomeMethod()
        {
            if (list.Count == 0)
            {
                target = new Target();
                list.Add(target);
            }
            else
                target = list[0];
        }

        public Target Instance { get { return target; } }
    }

    [TestClass]
    public class ClientSideSingleton
    {
        [TestMethod]
        public void Test()
        {
            var client1 = new Client();
            client1.SomeMethod();
            var client2 = new Client();
            client2.SomeMethod();
            Assert.AreEqual<int>(client1.Instance.GetHashCode(), client2.Instance.GetHashCode());
        }
    }
}
