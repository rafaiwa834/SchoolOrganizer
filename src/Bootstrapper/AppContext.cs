using System.Reflection;
using SchoolOrganizer.Shared.Abstractions.Module;

namespace Bootstrapper;

public sealed record AppContext(List<Assembly> LoadedAssemblies, List<Assembly> ModuleAssemblies, HashSet<IModule> LoadedModules);