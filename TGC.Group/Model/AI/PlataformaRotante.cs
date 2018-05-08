﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGC.Core.Mathematica;
using TGC.Core.SceneLoader;
using TGC.Core.Collision;

namespace TGC.Group.Model.AI
{
    class PlataformaRotante : Plataforma
    {
        private TgcMesh plataformaMesh;
        private Escenario escenario;
        public float anguloRotacion;

        public PlataformaRotante(TgcMesh plataformaMesh, Escenario escenario) : base(plataformaMesh, escenario)
        {
            this.plataformaMesh = plataformaMesh;
            this.escenario = escenario;
            this.plataformaMesh.AutoTransform = false;
            this.anguloRotacion = FastMath.ToRad(1f);
        }

        public override void Update()
        {

            plataformaMesh.Transform = TGCMatrix.RotationY(anguloRotacion);
            

        }
    }
}