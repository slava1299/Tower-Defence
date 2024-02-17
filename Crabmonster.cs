using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crabmonster : MonoBehaviour
{
    private float Speed = 0.4f;
    private float RotationSpeed = 2.2f;
    public Transform[] Points;
    private Transform currentPoint;
    private Transform do_currentPoint;
    private int index, tochka;
    private Vector3 direction;
    public float dist;
    public static float destroy_mob;
    public float Starthp=50;
    public float hp;

    void Start()
    {
        index = 0; tochka = 1;
        currentPoint = Points[index];
        do_currentPoint = Points[tochka];
        hp = Starthp;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            
            hp -= collision.gameObject.GetComponent<Bullet>().Damage;
            Destroy(collision.gameObject);
            if (hp <= 0)
                Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, Time.deltaTime * Speed);//�������� �����
       // direction = currentPoint.position - transform.position;// ����������� �� ���� � ��������
        dist = Vector3.Distance(currentPoint.position, transform.position);
        if (dist < 0.25 && index!=Points.Length-1)
        {// �� 0,25 �� ������ ����� ��������� ������������ ������ ����� � ����� ����������, ����� �������� ����������� 
            
            do_currentPoint = Points[tochka];

            direction = do_currentPoint.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, Time.deltaTime * RotationSpeed, 0); // ����� �����������: ������ ������-����� � �����������
            transform.rotation = Quaternion.LookRotation(newDirection);//������� � ������ �����������
        } 

   

            if (transform.position == currentPoint.position)
            {
                index++; tochka++;

                if (index >= Points.Length)
                {
                    Destroy(gameObject);
                destroy_mob++;
                }
                else
                {
                    currentPoint = Points[index];
                }
            }



        }
    }

