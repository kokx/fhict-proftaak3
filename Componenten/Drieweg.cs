﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fhict_proftaak3.Componenten
{
    public abstract class Drieweg : IKruispunt
    {
        protected KruispuntWachtrij[] kruispunten;

        public Drieweg()
        {
            this.kruispunten = new KruispuntWachtrij()[3];
        }

        public void addAuto(Auto auto, IKruispunt afkomst)
        {

        }

        public void removeAuto(Auto auto, IKruispunt afkomst)
        {
        }

        public void addKruispunt(IKruispunt kruispunt)
        {
            kruispunten.Add(new KruispuntWachtrij(kruispunt));
        }
    }
}
