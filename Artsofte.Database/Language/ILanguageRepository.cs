using System.Collections.Immutable;
using System.Threading.Tasks;

namespace Artsofte.Database.Language;

public interface ILanguageRepository
{
    Task<LanguageModel> GetOneById(int id);
    
    Task<ImmutableArray<string>> ListAllLanguageNames();
}