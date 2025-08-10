/*
class Node {
    int data;
    Node left, right;

    public Node(int d) {
        data = d;
        left = right = null;
    }
}
*/
class Solution {
    boolean findTarget(Node root, int target) {
        // Write your code here
        ArrayList<Integer> arr = new ArrayList<>();
        
        Inorder(root, arr);
        
        return Search(arr, target);
    }
    
    void Inorder(Node root, ArrayList<Integer> arr){
        if(root == null) return;
        
        Inorder(root.left, arr);
        arr.add(root.data);
        Inorder(root.right, arr);
    }
    
    boolean Search(ArrayList<Integer> arr, int target){
        int left = 0, right = arr.size()-1;
        
        while(left < right){
            if(arr.get(left) + arr.get(right) == target) return true;
        
            if(arr.get(left) + arr.get(right) > target){
                right--;
            }
            else{
                left++;
            }
        }
        
        return false;
        
    }
}