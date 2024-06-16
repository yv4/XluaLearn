print("Hellos")
--如果要调用类中私有方法 需要这段代码
xlua.private_accessible(CS.SpawnUI)
xlua.hotfix(CS.SpawnUI,'SpawnObj',function(self)
	for i=0,4,1 do
		print("HotFix")
		local go = CS.UnityEngine.GameObject.Instantiate(self.UIPrefab)
		local v3 = CS.UnityEngine.Vector3(i * 250,0,0)
		local v3One = CS.UnityEngine.Vector3.one;
		go.transform:SetParent(self.Canvas.transform)
		go.transform.localPosition = v3
		go.transform.localScale=v3One
	end
	print("SpawnObj")
end)