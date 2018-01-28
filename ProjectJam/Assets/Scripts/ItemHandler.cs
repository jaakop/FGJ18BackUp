using UnityEngine;
using TMPro;

public class ItemHandler : MonoBehaviour
{
    public const float MaxRayDistance = 20f;

    public static Item Item;
    public static Pipe ActivePipe;

    public bool Gun = false;
    
    [SerializeField]
    private TextMeshProUGUI Name;
    
    private Vector3 GetDirection (Vector3 a, Vector3 b)
    {
        var direction = b - a;
        return direction.magnitude < 1 ? direction : direction.normalized;
    }

    public void Update()
    {
        if (Item == null)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, MaxRayDistance, 1))
            {
                if (hit.transform.tag == "Item")
                {
                    Name.SetText(hit.transform.name);
                }
                else if (hit.transform.tag == "Button")
                {
                    if (hit.transform.name == "Call")
                    {
                        Name.SetText("Call Bob");
                    }
                    else if (hit.transform.name == "Order")
                    {
                        Name.SetText("Order a pipe");
                    }
                }
                else
                {
                    Name.SetText("");
                }

                if (Input.GetMouseButtonDown(0))
                {
                    if (hit.transform.tag == "Item")
                    {
                        Item = hit.transform.GetComponent<Item>();
                        Item.SetMoveState(true);
                    }
                    else if (hit.transform.tag == "Button")
                    {
                        if (hit.transform.name == "Call")
                        {
                            hit.transform.GetComponent<SteamRadio>().Call();
                        }
                        else if (hit.transform.name == "Order")
                        {
                            hit.transform.GetComponent<PipeSpawner>().Spawn();
                        }                     
                    }
                }
            }
            else
            {
                Name.SetText("");
            }
        }
        else
        {
            Name.SetText("");

            if (Input.GetMouseButtonUp(0))
            {
                if (!Item.isVisible())
                {
                    Destroy(Item.gameObject);

                    ActivePipe.SetFixed();
                    ActivePipe = null;
                    Item = null;
                    return;
                }

                Item.GetComponent<Item>().SetMoveState(false);
                Item = null;
            }
        }    
    }

    public void FixedUpdate()
    {
        if (Item != null)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.transform.tag == "Objective")
                {
                    if (ActivePipe == null)
                    {
                        ActivePipe = hit.collider.GetComponent<Pipe>();
                        ActivePipe.SetPreviewVisible(true);

                        Item.SetVisible(false);
                    }                
                }
                else
                {
                    if (ActivePipe != null)
                    {
                        ActivePipe.SetPreviewVisible(false);
                        ActivePipe = null;

                        Item.SetVisible(true);
                    }                              
                }
            }

            Item.GetComponent<Rigidbody>().velocity = GetDirection(Item.transform.position, transform.position + transform.forward * 8) * 20;
        }       
    }
}
