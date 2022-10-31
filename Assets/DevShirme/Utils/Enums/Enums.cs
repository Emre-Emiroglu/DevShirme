namespace DevShirme.Utils
{
    public class Enums
    {
        public enum DestroyType
        {
            DestroyNewObj,
            DestroyOldObj
        }
        public enum MovementType
        {
            Transform,
            Rigidbody,
        }
        public enum TriggerBehavior : int
        {
            OnTriggerEnter = 1,
            OnTriggerExit = 2,
            Both = 3
        }
        public enum ManagerType: int
        {
            DataManager = 0,
            PoolManager = 1,
            GameManager = 2,
            UIManager = 3
        }
    }
}
