public class StatObject
{
    public string adjustmentName{ get; set; }
    public float shootingSpeedChange{ get; set; }
    public float movementSpeedChange{ get; set; }
    public float damageChange{ get; set; }

    public StatObject(string adjustmentName, float shootingSpeedChange, float movementSpeedChange, float damageChange)
    {
        this.adjustmentName = adjustmentName;
        this.shootingSpeedChange = shootingSpeedChange;
        this.movementSpeedChange = movementSpeedChange;
        this.damageChange = damageChange;
    }
}
