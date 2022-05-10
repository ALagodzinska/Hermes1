using Data;
using Entity;
namespace Services
{
    public class BLL
    {
        private readonly DLL _dataLogic;

        public BLL()
        {
            _dataLogic = new DLL();
        }
        public List<Users> GetUsersList()
        {
            return _dataLogic.GetUser();
        }

        public void CreateUser(Users user)
        {
            _dataLogic.CreateUser(user);
        }
        public void DeleteUser(int id)
        {
            _dataLogic.DeleteUser(id);
        }
        public void UpdateUser(Users user)
        {
            _dataLogic.UpdateUser(user);
        }

        public List<Room> GetRoomList()
        {
            return _dataLogic.GetRoom();
        }

        public void CreateRoom(Room room)
        {
            _dataLogic.CreateRoom(room);
        }

        public void DeleteRoom(int id)
        {
            _dataLogic.DeleteRoom(id);
        }
    }
}