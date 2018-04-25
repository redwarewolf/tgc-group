﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGC.Core.Example;
using TGC.Core.Geometry;
using TGC.Core.Mathematica;
using TGC.Core.SceneLoader;
using TGC.Core.Textures;
using TGC.Core.SkeletalAnimation;
using TGC.Core.Collision;
using TGC.Core.BoundingVolumes;

namespace TGC.Group.Model
{
    class Escenario
    {
       public TgcScene scene { get; set; }

        public Escenario(string pathEscenario)
        {
            var loader = new TgcSceneLoader();
            scene = loader.loadSceneFromFile(pathEscenario);
        }

        public List<TgcMesh> Paredes()=> scene.Meshes.FindAll(x => x.Layer == "PAREDES");

        public List<TgcMesh> Rocas()=> scene.Meshes.FindAll(x => x.Layer == "ROCAS");
        
        public List<TgcMesh> Pisos() => scene.Meshes.FindAll(x => x.Layer == "PISOS");

        public List<TgcMesh> Cajas() => scene.Meshes.FindAll(x => x.Layer == "CAJAS");

        public List<TgcMesh> MeshesColisionables()
        {
            List<TgcMesh> meshesColisionables = new List<TgcMesh>();
            meshesColisionables.AddRange(Paredes());
            meshesColisionables.AddRange(Rocas());
            meshesColisionables.AddRange(Pisos());
            meshesColisionables.AddRange(Cajas());

           return meshesColisionables;
        }

        public List<TgcBoundingAxisAlignBox> MeshesColisionablesBB()
        {
            return MeshesColisionables().Select(mesh => mesh.BoundingBox).ToList();
        }

        public List<TgcMesh> ObjetosColisionables()
        {
            return Paredes().Concat(Rocas()).Concat(Cajas()).ToList();
        }
        
        public void RenderizarBoundingBoxes()
        {
            MeshesColisionables().ForEach(mesh => mesh.BoundingBox.Render());
        }

        public void RenderAll() => scene.RenderAll();
        
        public void DisposeAll() => scene.DisposeAll();
        
        public TgcBoundingAxisAlignBox BoundingBox() => scene.BoundingBox;

        public List<TgcBoundingAxisAlignBox> MeshesColisionablesBBSin(TgcMesh box)
        {
            List<TgcMesh> obstaculos = MeshesColisionables();
            var indice = -1;
            indice = obstaculos.FindIndex(mesh => mesh.Name == box.Name);

            if (indice != -1) obstaculos.RemoveAt(indice);
            return obstaculos.ConvertAll(mesh => mesh.BoundingBox);
        }

       
    }
}
