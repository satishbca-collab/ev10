public class Solution {
    public int[] SortArray(int[] nums) {
        return bucketSort(nums);
    }

    private void swap(int[] nums, int i, int j){
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }

    private int[] bubble(int[] nums){
        int n = nums.Length;
        for(int i = 0; i < n; i++){
            for(int j = 0; j < n - i - 1; j++){
                if(nums[j] > nums[j+1]){
                    int temp = nums[j];
                    nums[j] = nums[j+1];
                    nums[j+1] = temp;
                }
            }
        }
        return nums;
    }

    private int[] selection(int[] nums){
        int n = nums.Length;

        for(int i = 0; i < n; i++){
            int index = i;
            for(int j = i + 1; j < n; j++){
                if(nums[j] < nums[index]){
                    index = j;
                }
            }
            if(index != i){
                int temp = nums[index];
                nums[index] = nums[i];
                nums[i] = temp;
            }
        }

        return nums;
    }

    private int[] insertion(int[] nums){
        int n = nums.Length;

        for(int i = 1; i < n; i++){
            int j = i-1, key = nums[i];
            while(j >= 0 && nums[j] > key){
                nums[j + 1] = nums[j];
                j--;
                
            }
            nums[j + 1] = key;
        }

        return nums;
    }

    #region MergeSort
    private int[] mergesort(int[] nums){
        int n = nums.Length;
        MergeSortHelper(nums, 0, n - 1);
        return nums;
    }

    private void MergeSortHelper(int[] nums, int low, int high){
        if(low >= high){
            return;
        }

        int mid = low + (high - low)/2;

        MergeSortHelper(nums, low, mid);
        MergeSortHelper(nums, mid + 1, high);
        Merge(nums, low, mid, high);
    }

    private void Merge(int[] nums, int low, int mid, int high){
        int m = mid - low + 1, n = high - mid;

        var left = new int[m];
        var right = new int[n];

        for(int i = 0; i < m; i++){
            left[i] = nums[low + i];
        }

        for(int i = 0; i < n; i++){
            right[i] = nums[mid + 1 + i];
        }

        int k = low, l = 0, r = 0;

        while(l < m && r < n){
            if(left[l] < right[r]){
                nums[k++] = left[l++];
            }
            else {
                nums[k++] = right[r++];
            }
        }

        while(l < m){
            nums[k++] = left[l++];
        }

        while(r < n){
            nums[k++] = right[r++];
        }
    }
    #endregion

    #region QuickSort
    private int[] quicksort(int[] nums){
        int n = nums.Length;
        QuickSortHelper(nums, 0, n - 1);
        return nums;
    }

    private void QuickSortHelper(int[] nums, int left, int right){
        if(left >= right) return;
        int p = Partition(nums, left, right);
        QuickSortHelper(nums, left, p - 1);
        QuickSortHelper(nums, p + 1, right);
    }

    private int Partition(int[] nums, int left, int right){
        int p = nums[right];
        int i = left, j = right - 1;

        while(i <= j){
            while(i <= j && nums[i] < p){
                i++;
            }
            while(i <= j && nums[j] > p){
                j--;
            }

            if(i <= j){
                swap(nums, i, j);
                i++;
                j--;
            }
        }

        swap(nums, i, right);

        return i;
    }
    #endregion

    # region Non-Comparison sorting algorithms
    private int[] countsort(int[] nums){
        int n = nums.Length, max = Int32.MinValue, min = Int32.MaxValue;

        for(int i = 0; i < n; i++){
            min = Math.Min(min, nums[i]);
            max = Math.Max(max, nums[i]);
        }

        var table = new int[max-min+1];

        for(int i = 0; i < n; i++){
            int key = nums[i] - min;
            table[key]++;
        }

        for(int i = 1; i < table.Length; i++){
            table[i] = table[i] + table[i-1];
        }

        var result = new int[n];
        for(int i = n - 1; i >= 0; i--){
            int key = nums[i] - min;
            table[key]--;
            int index = table[key];
            result[index] = nums[i];
        }

        return result;
    }

    private int[] bucketSort(int[] nums){
        int n = nums.Length, max = Int32.MinValue, min = Int32.MaxValue;

        for(int i = 0; i < n; i++){
            min = Math.Min(min, nums[i]);
            max = Math.Max(max, nums[i]);
        }

        int range = max - min;
        int bucketSize = Math.Max(1, range/n); // 1 to ensure min bucket size when range(100) < n(1M)
        int bucketCount = range/bucketSize + 1; // 1 to accomodate max value

        List<int>[] buckets = new List<int>[bucketCount];
        for(int i = 0; i < bucketCount; i++){
            buckets[i] = new List<int>();
        }

        foreach(int num in nums){
            int index = (num - min) / bucketSize;
            buckets[index].Add(num);
        }

        int idx = 0;
        foreach(var bucket in buckets){
            bucket.Sort();
            foreach(int num in bucket){
                nums[idx++] = num;
            }
        }
        return nums;
    }

    #endregion
}