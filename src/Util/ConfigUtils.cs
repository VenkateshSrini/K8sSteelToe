using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k8s;
using k8s.KubeConfigModels;

namespace k8sConfigs.Util
{
    public static class ConfigUtils
    {
        public static KubernetesClientConfiguration GetKubernetesClientConfiguration(string appRunIn)
{
            if (appRunIn.ToLower() == "local")
                return KubernetesClientConfiguration.BuildConfigFromConfigFile();
            else
                return KubernetesClientConfiguration.InClusterConfig();
        }
    }
}
