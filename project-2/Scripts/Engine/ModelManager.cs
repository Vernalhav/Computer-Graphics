﻿using System;
using System.Collections.Generic;
using System.IO;

namespace World_3D
{

    public struct ModelPaths
    {
        private const string baseFolder = "..\\..\\..\\Models";
        public readonly string modelPath;
        public readonly string mtlPath;
        public readonly string textureFolderPath;

        public ModelPaths(string modelName)
        {
            this.modelPath = Path.Combine(baseFolder,modelName,modelName + ".obj");
            this.mtlPath = Path.Combine(baseFolder,modelName, modelName + ".mtl");
            this.textureFolderPath = Path.Combine(baseFolder, modelName, "textures");
        }
    }

    public static class ModelManager
    {
        private static Dictionary<ModelType, Mesh> loadedMeshes = new();
        private static Dictionary<ModelType, ModelPaths> meshPaths = new() {
            { ModelType.Bear, new ModelPaths("bear") },
            { ModelType.Skybox, new ModelPaths("skycube") },
            { ModelType.Griffin, new ModelPaths("griffin") },
            { ModelType.Terrain, new ModelPaths("terrain") },
            { ModelType.Ship, new ModelPaths("ship") },
            { ModelType.FishermanHouse, new ModelPaths("fisherman") },
        };

        public static Mesh GetModel(ModelType modelType)
        {
            if (!loadedMeshes.TryGetValue(modelType, out Mesh returnMesh))
            {
                returnMesh = CreateModel(modelType);

                loadedMeshes[modelType] = returnMesh;
            }

            return returnMesh;

        }

        private static Mesh CreateModel(ModelType modelType)
        {
            Mesh newModel;

            if (meshPaths.TryGetValue(modelType, out ModelPaths md))
            {
                newModel = new Mesh(ModelReader.ReadAll(md.modelPath, md.mtlPath, md.textureFolderPath));
            }
            else
            {
                throw new ArgumentException($"Model {modelType} not found");
            }

            return newModel;
        }
    }
}
