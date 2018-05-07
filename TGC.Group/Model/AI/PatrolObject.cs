﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGC.Core.Mathematica;
using TGC.Core.SceneLoader;

namespace TGC.Group.Model.AI
{
    abstract class PatrolObject
    {
        private TgcMesh objectMesh;
        private List<TGCVector3> positions;
        private int currentPoint = 0;

        public PatrolObject(List<TGCVector3> newPositions, TgcMesh theObjectsMesh)
        {
            positions = newPositions;
            objectMesh = theObjectsMesh;
        }

        public void Update()
        {

        }

        public void PatrolLogic()
        {
            if (TGCVector3.Equals(objectMesh.Position, positions[currentPoint]))
            {
                currentPoint++;
            }
            if( currentPoint == positions.Count && TGCVector3.Equals(objectMesh.Position, positions[currentPoint]))
            {
                currentPoint = 0;
                positions.Reverse();
            }
            objectMesh.Move(TGCVector3.Normalize(positions[currentPoint]));
        }
    }
}