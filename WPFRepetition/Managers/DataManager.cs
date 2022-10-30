using WPFRepetition.Models;

namespace WPFRepetition.Managers;

class DataManager : IDataManager
{
    private DataModel _dataModel = new DataModel();

    public DataModel DataModel => _dataModel;
        
}