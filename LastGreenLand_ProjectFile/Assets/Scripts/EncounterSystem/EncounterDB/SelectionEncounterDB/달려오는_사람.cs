public class �޷�����_��� : Selection_Encounter
{
    public �޷�����_���()
    {
        precondition = true;
        beforeContext = "�� ����� �޷��ɴϴ�. �Ÿ��� �ް��� ����������ϴ�. �׿� ����, ������ �� �� ������ �ͱ��� �������ϴ�.\n" +
                        "<color=green>(������ ��������?)</color>";
        options = new Option[]
        {
            new(optionScript: "�� ���� Į",
                afterContext: "�� ����� �տ� �� ���� Į�� ��� �־����ϴ�!",
                afterEncounter: new ���θ�����_�ο�()),
            new(optionScript: "������ ��",
                afterContext: "������ �� ���̷� ���̴� ������� ���� ������ ���� ��Ǫ���� ����ϴ�.",
                afterEncounter: new ��ü����_�ο�())
        };
    }
}