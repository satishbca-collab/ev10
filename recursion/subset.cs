public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        var result = new List<IList<int>>();
        Helper(nums, 0, new List<int>(), result);
        return result;
    }

    private void Helper(int[] nums, int index, List<int> current, IList<IList<int>> result){
        if(index == nums.Length){
            result.Add(new List<int>(current));
            return;
        }

        current.Add(nums[index]);
        Helper(nums, index+1, current, result);

        current.RemoveAt(current.Count - 1);
        Helper(nums, index+1, current, result);
    }
}