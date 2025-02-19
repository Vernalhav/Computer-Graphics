﻿using System;
using System.Collections.Generic;
using Tutorial;

namespace World_3D
{
    public class GameObject
    {
        public Transform Transform { get => transform; set => transform = value; }
        private Transform transform = new();

        private readonly List<Component> components = new();


        public void AddComponent(Component c)
        {
            c.parent = this;
            components.Add(c);
        }

        public void Update(double deltaTime)
        {
            foreach(Component c in components)
            {
                c.Update(deltaTime);
            }
        }

        internal void Start()
        {
            foreach (Component c in components)
            {
                c.Start();
            }
        }
    }
}
