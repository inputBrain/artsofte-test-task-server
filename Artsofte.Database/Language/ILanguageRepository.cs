using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace Artsofte.Database.Language;

public interface ILanguageRepository
{
    Task<LanguageModel> GetOneById(int id);

    Task<List<LanguageModel>> ListAll();
    Task<ImmutableArray<string>> ListAllOnlyNames();
}