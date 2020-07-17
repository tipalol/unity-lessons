using UnityEngine;

public class PlayerControl : MonoBehaviour
{


    // Ссылка на компонент Transform - для движения, поворота и изменения размера
    public Transform Self;
    // Ссылка на компонент Rigidbody2D - для работы с физикой (например для прыжка или толчка)
    public Rigidbody2D Rigidbody;
    // Ссылка на компонент SpriteRenderer - для отрисовки спрайта,
    // изменения картинки, цвета или поворота изображения
    public SpriteRenderer Renderer;

    // Целочисленная переменная Speed - отвечает за скорость, изменяем ее в редакторе Unity
    public int Speed;
    // Целочисленная переменная JumpForce - отвечает за силу прыжка, изменяем ее в редакторе Unity
    public int JumpForce;

    // Делаем то, что в фигурных скобках один раз при старте игры
    void Start()
    {
        // Перемещаемся в точку 0;0;0 (xyz)
        Self.position = new Vector3(0, 0, 0);
    }

    // Делаем то, что в фигурных скобках каждый кадр
    void Update()
    {
        // Если клавиша D нажата
        if (Input.GetKey(KeyCode.D))  
        {
            // То двигаемся направо (сдвигаемся по x на 0.1)
            Self.Translate(new Vector3(0.01f * Speed, 0, 0));
            // Отражаем изображение по горизонтали - персонаж смотрит вправо
            Renderer.flipX = true;
        }
            

        // Если клавиша A нажата
        if (Input.GetKey(KeyCode.A)) 
        {
            // То двигаемся налево (сдвигаемся по x на -0.1)
            Self.Translate(new Vector3(-0.1f * Speed, 0, 0));
            // Возвращаем исходное изображение - персонаж смотрит влево
            Renderer.flipX = false;
        }
        
        // Если клавиша пробел нажата
        if (Input.GetKeyDown(KeyCode.Space))
            // То прыгаем - прикладываем силу, направленную вверх
            Rigidbody.AddForce(new Vector2(0, 1f * JumpForce));
    }
}
